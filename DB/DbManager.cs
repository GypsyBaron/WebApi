using System.Collections.Generic;
using System;

namespace DB
{
    public class DbManager
    {
        private static List<Hug> _hugs = new List<Hug>();
        
        static DbManager()
        {
            _hugs = new List<Hug>();
            _hugs.Add(new Hug { From = "A", To = "B", Reason = "Reason 1", Created = DateTime.Now, Id = 1});
            _hugs.Add(new Hug { From = "B", To = "C", Reason = "Reason 2", Created = DateTime.Now, Id = 2});
            _hugs.Add(new Hug { From = "C", To = "D", Reason = "Reason 3", Created = DateTime.Now, Id = 3});
            _hugs.Add(new Hug { From = "D", To = "E", Reason = "Reason 4", Created = DateTime.Now, Id = 4});
            _hugs.Add(new Hug { From = "E", To = "F", Reason = "Reason 5", Created = DateTime.Now, Id = 5});
        }

        // private readonly FileLogger _logger;

        //public DbManager();
       

        public List<Hug> GetHugs()
        {
           // public logger = new FileLogger();
           // _logger.Log("getting hugs");
            return _hugs;
        }

        public bool DeleteById(int id)
        {
            Hug hugToDelete = _hugs.Find(h => h.Id == id);
            if (hugToDelete != null)
            {
                _hugs.Remove(hugToDelete);
                return true;
            }
            else return false;
        }

        public void AddNewModel(Hug model)
        {
            _hugs.Add(model);
        }

        public void PutHug(Hug model)
        {
            var newHug = _hugs.Find(x => x.Id == model.Id);
            if (newHug != null)
            {
                int index = _hugs.IndexOf(newHug);
                _hugs[index] = model;
            }
        }

        public void PatchHug(Hug model)
        {
            var newHug = _hugs.Find(x => x.Id == model.Id);
            if (newHug != null)
            {
                int index = _hugs.IndexOf(newHug);

                if (newHug.From != null) _hugs[index].From = model.From;
                if (newHug.To != null) _hugs[index].To = model.To;
                if (newHug.Reason != null) _hugs[index].Reason = model.Reason;
                if (newHug.Created != null) _hugs[index].Created = model.Created;
            }
        }
    }
}
