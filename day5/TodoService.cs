using System;
using System.Collections.Generic;


namespace CrudBasic
{
    public class TodoService
    {
        public void AddTodo(string task, string desc)
        {
            DBHelper.Instance.Execute("Insert_todos@Training1.DB", Tool.ToDic(
            "task", todo.Task, "desc", todo.Desc));
        }

        public List<Dictionary<string, object>> GetAllTodos()
        {
            return Tool.ToListDic(DBHelper.Instance.Query("Select_todos@Training1.DB", Tool.ToDic()));
        }
        public List<Dictionary<string, object>> GetTodosByTask(string task)
        {
            return Tool.ToListDic(DBHelper.Instance.Query("Select_todos@Training1.DB", Tool.ToDic("task", task)));
        }

        public void EditTodo(int id, string task, string desc)
        {
            DBHelper.Instance.Execute("Update_todos@Training1.DB", Tool.ToDic("task", task, "desc", desc, "todo_id__W", id));
        }
        public void DoneTodo(int id, bool status)
        {
            DBHelper.Instance.Execute("Update_todos@Training1.DB", Tool.ToDic("status", status, "todo_id__W", id));
        }

        public void DeleteTodo(int id)
        {
            DBHelper.Instance.Execute("Delete_todos@Training1.DB", Tool.ToDic("todo_id", id));
        }
    }
}