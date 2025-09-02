using Bl.Migrations;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface Iitemimage
    {
        public List<TbItemImage> GetALL();
        public List<VwItemImage> GetALLitemimage();
        public TbItemImage GetById(int id);
        public bool Save(TbItemImage item);
        public bool Delete(int id);
    }
    public class ClsItemImages: Iitemimage
    {
        LapShopContext _context;
        public ClsItemImages(LapShopContext context)
        {
            _context = context;
        }

        public List<VwItemImage> GetALLitemimage()
        {
            try
            {
                var itemimage= (from i in _context.TbItems join c in _context.TbItemImages
                               on i.ItemId equals c.ItemId
                                where i.currentstate == 1 && c.currentstate == 1
                                select new VwItemImage() 
                               {
                                    ImageId=c.ImageId,
                                   ImageName=c.ImageName,
                                   ItemName=i.ItemName
                               }).ToList();
                return itemimage;
            }
            catch
            {
                return new List<VwItemImage>();
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

        public List<TbItemImage> GetALL()
        {
            try
            {
                var item = _context.TbItemImages.Where(a => a.currentstate == 1).ToList();
                return item;
            }
            catch
            {
                return new List<TbItemImage>();
            }
        }

        public TbItemImage GetById(int id)
        {
            try
            {

                var item = _context.TbItemImages.FirstOrDefault(a => a.ImageId == id);
                return item;
            }
            catch
            {
                return new TbItemImage();
            }
        }

        public bool Save(TbItemImage item)
        {
            try
            {
                item.currentstate = 1;

                if (item.ImageId == 0)
                {
                    item.createdby = "1";
                    item.createddate = DateTime.Now;
                    _context.TbItemImages.Add(item);
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
