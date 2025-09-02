using Bl.Migrations;
using Domains;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface Iitems
    {
        public List<Tbitem> GetALL();
        public List<VwItemHomePage> GetALLitemcategory();
        public List<Tbitem> GetALLitem();
        public List<TbItemImage> GetALLitemHomePage(int id);
        public List<Tbitem> Getrecommended(int id);

        public Tbitem GetById(int id);
        public bool Save(Tbitem item);
        public bool Delete(int id);
    }
    public class ClsItems : Iitems
    {
        LapShopContext _context;
        public ClsItems(LapShopContext context)
        {
            _context = context;
            
        }
        public List<VwItemHomePage> GetALLitemcategory()
        {
            try
            {
                var itemcategory= (from i in _context.TbItems join c in _context.TbCategories
                                  on i.Categoryid equals c.Categoryid where i.currentstate==1 
                                  select new VwItemHomePage()
                                  {
                                      ItemId=i.ItemId,
                                      ItemName=i.ItemName,
                                      ItemImageName=i.imagename,
                                      SalesPrice=i.SalesPrice,
                                      CategoryName=c.CategoryName,
                                      CategoryImageName=c.ImageName
                                  }).ToList();
                return itemcategory;
            }
            catch
            {
                return new List<VwItemHomePage>();
            }
        }
        public List<TbItemImage> GetALLitemHomePage(int id)
        {
            try
            {
                var itemcategory = (from i in _context.TbItemImages
                                    where i.ItemId==id
                                    
                                   
                                    select new TbItemImage()
                                    {
                                      ImageId=i.ImageId,
                                      ImageName=i.ImageName,
                                     
                                    }).Take(4).ToList();
                return itemcategory;
            }
            catch
            {
                return new List<TbItemImage>();
            }
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

        public List<Tbitem> GetALL()
        {
            try
            {
                var item=_context.TbItems.Where(a => a.currentstate == 1).ToList();
                return item;
            }
            catch
            {
                return new List<Tbitem>();
            }
        }
        public List<Tbitem> GetALLitemimages()
        {
            try
            {
                var item = _context.TbItems.Where(a => a.currentstate == 1).ToList();
                return item;
            }
            catch
            {
                return new List<Tbitem>();
            }
        }
        public List<Tbitem> GetALLitem()
        {
            try
            {
                var item = _context.TbItems.Where(a=>a.currentstate==1).ToList();
                item.Select(a=>new Tbitem()
                {
                     ItemId=a.ItemId,
                     ItemName=a.ItemName
                });
                return item;
            }
            catch
            {
                return new List<Tbitem>();
            }
        }

        public Tbitem GetById(int id)
        {
            try
            {
           
                var item = _context.TbItems.FirstOrDefault(a=>a.ItemId==id);
                return item;
            }
            catch 
            {
               return new Tbitem();
            }
        }
        public List<Tbitem> Getrecommended(int id)
        {
            try
            {
                var itemid=GetById(id);

                var item = _context.TbItems.Where(a=>(a.SalesPrice<=itemid.SalesPrice+400 && a.SalesPrice>=itemid.SalesPrice-400)).Take(4).ToList();
                item.Select(a => new Tbitem() 
                {
                   ItemId = a.ItemId,
                   ItemName=a.ItemName,
                   SalesPrice=a.SalesPrice,
                
                });
                return item;
            }
            catch
            {
                return new List<Tbitem>();
            }
        }


        public bool Save(Tbitem item)
        {
            try
            {
                item.currentstate = 1;

                if (item.ItemId == 0)
                {
                    item.createdby = "1";
                    item.createddate = DateTime.Now;
                    _context.TbItems.Add(item);
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
