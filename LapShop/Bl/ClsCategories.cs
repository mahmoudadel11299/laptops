using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{

    public interface Icategories
    {
        public List<TbCategory> GetALL();
        public List<TbCategory> GetCategoryId();
        public TbCategory GetById(int id);
        public bool Save(TbCategory item);
        public bool Delete(int id);
    }
    public class ClsCategories : Icategories
    {
        LapShopContext _context;
        public ClsCategories(LapShopContext context)
        {
            _context = context;
        }
        public List<TbCategory> GetCategoryId()
        {
            var item = _context.TbCategories.Where(a=>a.currentstate==1).ToList();
            item.Select(s=>new TbCategory()
            {
                Categoryid = s.Categoryid,
                CategoryName=s.CategoryName
            }
            );
            return item;
        }


        public bool Delete(int id)
        {
            try
            {
                var item = GetById(id);
                if (item != null)
                {
                    item.currentstate = 0;
                    _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TbCategory> GetALL()
        {
            try
            {
                var item = _context.TbCategories.Where(a=>a.currentstate==1).ToList();
                return item;
            }
            catch
            {
                return new List<TbCategory>();
            }
        }

        public TbCategory GetById(int id)
        {
            try
            {

                var item = _context.TbCategories.FirstOrDefault(a => a.Categoryid == id);
                return item;
            }
            catch
            {
                return new TbCategory();
            }
        }

        public bool Save(TbCategory item)
        {
            try
            {
                item.currentstate = 1;

                if (item.Categoryid == 0)
                {
                    item.createdby = "1";
                    item.createddate = DateTime.Now;
                    _context.TbCategories.Add(item);
                }
                else
                {
                    
                    item.updatedby = "1";
                    item.updateddate = DateTime.Now;
                    _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    }
