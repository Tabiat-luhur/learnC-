function loadData() {
    const jsonService = {
        service: "TodoService.Class1.GetTodosDone",
        params: []
    };

    const url = "http://172.19.62.225/RIAService/AjaxServiceNew.ashx?JsonService=" +
        encodeURIComponent(JSON.stringify(jsonService));

    fetch(url)
        .then(response => response.json())
        .then(data => {
            if (data && data.Result && data.Result.length > 0) {
                renderTable(data.Result);
            } else {
                alert("Data tidak ditemukan");
            }
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Gagal mengambil data");
        });
}

function addTodo() {
    const jsonService = {
        service: "TodoService.Class1.AddTodo",
        params: ["test from UI", "ini desc"]
    };

    const url = "http://172.19.62.225/RIAService/AjaxServiceNew.ashx?JsonService=" +
        encodeURIComponent(JSON.stringify(jsonService));

    fetch(url)
        .then(response => response.json())
        .then(data => {
            if (data && data.Result && data.Result.length > 0) {
                renderTable(data.Result);
            } else {
                alert("Data tidak ditemukan");
            }
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Gagal menambah data");
        });
}

function deleteTodo(todoId) {
    if (confirm("Yakin mau hapus todo ini?")) {
        const jsonService = {
            service: "TodoService.Class1.DeleteTodo",
            params: [parseInt(todoId)]
        };

        const url = "http://172.19.62.225/RIAService/AjaxServiceNew.ashx?JsonService=" +
            encodeURIComponent(JSON.stringify(jsonService));

        fetch(url)
            .then(response => response.json())
            .then(() => loadData()) // setelah hapus, refresh data
            .catch(error => {
                console.error("Error:", error);
                alert("Gagal menghapus data");
            });
    }
}

function renderTable(data) {
    document.getElementById("dataTable").style.display = "table";

    const tableHeader = document.getElementById("tableHeader");
    const tableBody = document.getElementById("tableBody");

    // Kosongkan dulu isi tabel lama
    tableHeader.innerHTML = "";
    tableBody.innerHTML = "";

    const headers = Object.keys(data[0]);

    // buat header
    headers.forEach(header => {
        const th = document.createElement("th");
        th.textContent = header;
        tableHeader.appendChild(th);
    });

    // Tambahkan kolom Aksi
    const thAction = document.createElement("th");
    thAction.textContent = "Aksi";
    tableHeader.appendChild(thAction);

    // buat isi baris
    data.forEach(item => {
        const tr = document.createElement("tr");

        headers.forEach(key => {
            const td = document.createElement("td");
            td.textContent = item[key];
            tr.appendChild(td);
        });

        const tdAction = document.createElement("td");
        const deleteBtn = document.createElement("button");
        deleteBtn.textContent = "Hapus";
        deleteBtn.onclick = () => deleteTodo(item["todo_id"]);
        tdAction.appendChild(deleteBtn);

        tr.appendChild(tdAction);
        tableBody.appendChild(tr);
    });
}
