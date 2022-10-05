using System;
using DAL;
using Be;
using System.Collections.Generic;

namespace BLL
{
    public class BL_kala
    {
        DL_kala dl = new DL_kala();
        public void Create(Kala k)
        {
            dl.Create(k);
        }
        public int gettotal()
        {
            return dl.gettotal();
        }
        public List<Kala> read()
        {
            return dl.read();
        }
        public List<Kala> Filter(int catogryId, List<int> color, List<int> size, int min, int max)
        {
            return dl.Filter(catogryId, color, size, min, max);
        }
        public List<Kala> read(List<int> Ids)
        {
            return dl.read(Ids);
        }
        public List<Kala> getskip(int c)
        {
            return dl.getskip(c);
        }
        public List<Kala> read(int Id)
        {
            return dl.read(Id);
        }
        public List<Kala> search(string text)
        {
            return dl.search(text);
        }
        public void delet(int id)
        {
            dl.delet(id);
        }
        public void Update(int id, Kala k)
        {
            dl.Update(id,k);
        }
    }
}
