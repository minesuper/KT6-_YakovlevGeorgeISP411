using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetShop.Classes
{
    class ImgToByte
    {
        public static void ConvertImages()
        {
            var list = Model.TradeEntities.GetContext().Product.ToList();
            foreach (var item in list)
            {
                string path = Directory.GetCurrentDirectory() + "/ProductImages/" + item.ProductPhotoName;
                if (File.Exists(path))
                {
                    item.ProductPhoto = File.ReadAllBytes(path);
                }
            }
            Model.TradeEntities.GetContext().SaveChanges();
        }
    }
}
