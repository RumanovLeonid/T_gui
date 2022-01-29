using System;
using System.Collections.Generic;
using System.Linq;

namespace Terminal_TODO
{
    public class TodoList
    {
        private List<Todo> _TodoList = new();
        private readonly JSONLoadSave jls = new();

        public TodoList()
        {
           Load(jls);
        }

        public List<Todo> GetTodoList()
        {
            return _TodoList;
        }
        public List<Todo> GetTodoByDate(DateTime dateTime) 
        {
            var todoList = from item in _TodoList
                           where item.Date.Date.ToString().Contains(dateTime.Date.ToString())
                           orderby item.Date.ToString()
                           select item;

            return todoList.ToList();
        }
        public List<Todo> GetTodoByAuthor(string author)
        {
            var todoList = from item in _TodoList
                           where item.Author.Contains(author)
                           orderby item.Author
                           select item;

            return todoList.ToList();
        }
        //public List<Todo> GetTodoByHeader(string header)
        //{

        //}
        //Не реализован
        public List<Todo> GetTodoByContent(string content)
        {
            return new List<Todo>();
        }
        //Добавить элемент
        //Удалить элемент
        private void Load(ITodoLoadSave todoLoad)
        {
            _TodoList =  todoLoad.Load();
        }
        public void Save(ITodoLoadSave todoSave)
        {
            todoSave.Save(_TodoList);
        }
    }
}
