using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dallibrary;
using bal;


namespace helperlibrary
{
    public class Helper
    {
        DAL dal = null;
        public Helper()
        {
            dal = new DAL();
        }

        
        public bool AddE(BAL school)
        {
            return dal.Insert(school);

        }

        public bool Edit(BAL school)
        {
            return dal.Update(school);
        }

        public BAL search(int id)
        {
            return dal.Find(id);
        }
        public List<BAL> List()
        {
            return dal.List();
        }
        public bool remove(int id)
        {
            return dal.Delete(id);
        }
       
        public List<BAL> subList()
        {
            return dal.List1();
        }
        public bool Addsub(BAL school)
        {
            return dal.Insert1(school);

        }

        public bool editsub(BAL school)
        {
            return dal.Update1(school);
        }

        public BAL searchsub(int id)
        {
            return dal.Find1(id);
        }
        public bool removesub(int id)
        {
            return dal.Delete1(id);
        }

       
        public List<BAL> classList()
        {
            return dal.List2();
        }
        public bool Addclass(BAL school)
        {
            return dal.Insert2(school);

        }

        public bool editclass(BAL school)
        {
            return dal.Update2(school);
        }

        public BAL searchclass(int id)
        {
            return dal.Find2(id);
        }
        public bool removeclass(int id)
        {
            return dal.Delete2(id);
        }

    }
}