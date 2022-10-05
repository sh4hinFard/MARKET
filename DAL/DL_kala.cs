using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Be;
using Microsoft.EntityFrameworkCore;

namespace DAL
{

    public class DL_kala
    {
        db db1 = new db();
        public void Create(Kala k)
        {
            db1.kalas.Add(k);
            db1.SaveChanges();
        }
        public List<Kala> read()
        {
         return  db1.kalas.Include(i=>i.Catogory).ToList();
        }
        public List<Kala> read(List<int>Ids)
        {
            var q = from i in db1.kalas where Ids.Contains(i.Id) select i ;
            return q.ToList();
        }

        public List<Kala> Filter(int catogryId, List<int> color, List<int> size, int min, int max)
        {
            var kalas = db1.kalas.Include(i=>i.Color).Include(i=>i.Size).ToList();
            if (catogryId != 0)
            {
                kalas = kalas.Where(i => i.CatogoryId == catogryId).ToList();
            }

            if (color != null && color.Any())
            {
                foreach (var colors in color)
                {
                    kalas = kalas.Where(i => i.Color.Any(i => i.ColorId == colors)).ToList();
                }

            }


               
            if (size != null&&size.Any())
            {
               foreach(var sizes in size)
               {
                    kalas = kalas.Where(i => i.Size.Any(i => i.SizeId == sizes)).ToList();
               }
            }

            if (min != 0 & max != 0)
            {
                kalas = kalas.Where(i => i.Price >= min & i.Price <= max).ToList();
            }

            return kalas.ToList();
        }

        public int gettotal()
        {
            return db1.kalas.Count();
        }
        public List<Kala> getskip(int c)
        {
            int t = c * 10;
         var q = db1.kalas.Skip(t).Take(10).Include(i=>i.Catogory);
            return q.ToList();
        }
        public List<Kala> search(string text)
        {
          return db1.kalas.Where(i => i.Name.Contains(text)).Include(i => i.Catogory).ToList();
        }
        public List<Kala> read(int Id)
        {
            var q = (from i in db1.kalas where i.Id == Id select i).ToList();
           
            return q.ToList();
        }
        public void delet(int id)
        {
            var q = db1.kalas.Where(i => i.Id == id).FirstOrDefault();
            db1.Remove(q);
            db1.SaveChanges();

        }
        public void Update(int id, Kala k)
        {
            var q = db1.kalas.Where(i => i.Id == id).SingleOrDefault();

            q.Name = k.Name;
            q.Price = k.Price;
            q.Size = k.Size;
            q.Color = k.Color;
            q.Count = k.Count;
            q.CatogoryId = k.CatogoryId;
            q.Pic = k.Pic;
            db1.SaveChanges();

        }
    }
}
