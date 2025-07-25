function loadTodo() {
    const jsonService = {
        service: "TodoService.Class1.GetAllTodos",
        params: []
    };

    const url = "http://172.19.62.225/RIAService/AjaxServiceNew.ashx?JsonService=" + encodeURIComponent(JSON.stringify(jsonService));

    $.ajax({
        url: url,
        method: "GET",
        dataType: "json",
        success: function (response) {
            debugger
            if (response && response.Result && response["Result"].length > 0) {
                debugger
                renderTable(response["Result"]);
            } else {
                alert("Data tidak ditemukan");
            }
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
            alert("Gagal mengambil data");
        }
    });
}

function renderTable(data) {
    $("#dataTable").show();

    const headers = Object.keys(data[0]);

    // Tambahkan kolom "Action" untuk tombol delete
    const headerHtml = headers.map(key => `<th>${key}</th>`).join("") + `<th>Action</th>`;
    $("#tableHeader").html(headerHtml);

    const rowsHtml = data.map((row) => {
    const rowHtml = headers.map(h => `<td>${row[h] !== null ? row[h] : ''}</td>`).join("");
        
    // Pastikan row.todo_id ada
    const todoId = row["todo_id"] ?? "";
    const deleteButton = `<td><button onclick="deleteTodo('${todoId}')">Delete</button></td>`;

    return `<tr>${rowHtml}${deleteButton}</tr>`;
    }).join("");

    $("#tableBody").html(rowsHtml);
}
        
function addTodo(){
    const task = document.getElementById("task")
    const desc = document.getElementById("desc")
    const jsonService = {
        service: "TodoService.Class1.AddTodo",
        params: [task.value,desc.value]
    };
    const url = "http://172.19.62.225/RIAService/AjaxServiceNew.ashx?JsonService=" + encodeURIComponent(JSON.stringify(jsonService));
    $.ajax({
        url: url,
        method: "GET",
        dataType: "json",
        success: function (response) {
            alert("Data berhasil ditambahkan!");
            task.value = "";
            desc.value = "";
            loadTodo(); // langsung refresh data
        }
    });
}
        
function deleteTodo(todoId) {
    if (confirm("Are you sure you want to delete this todo?")) {
        const jsonService = {
            service: "TodoService.Class1.DeleteTodo",
            params: [parseInt(todoId)]
        };

        const url = "http://172.19.62.225/RIAService/AjaxServiceNew.ashx?JsonService=" + 
                     encodeURIComponent(JSON.stringify(jsonService));

        $.ajax({
            url: url,
            method: "GET",
            dataType: "json",
            success: function(response) {
                alert("Todo berhasil dihapus!");
                loadTodo(); // refresh todo
            },
            error: function(xhr, status, error) {
                console.error("Error:", error);
                alert("Gagal menghapus todo!");
            }
        });
    }
}
function searchTodo() {
    const cari=document.getElementById("search");
    const jsonService = {
        service: "TodoService.Class1.GetTodosByTask",
        params: [cari.value]
    };

    const url = "http://172.19.62.225/RIAService/AjaxServiceNew.ashx?JsonService=" + 
                     encodeURIComponent(JSON.stringify(jsonService));

    $.ajax({
        url: url,
        method: "GET",
        dataType: "json",
        success: function (response) {
            if (response && response.Result && response["Result"].length > 0) {
                debugger
                renderTable(response["Result"]);
            } else {
                alert("Data tidak ditemukan");
            }
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
            alert("Gagal mengambil data");
        }
    })
}
