using System.Collections.Generic;

namespace Terminal_TODO
{
    public interface ITodoLoadSave
    {
        public void Save(List<Todo> todos);
        public List<Todo> Load();
    }
}
