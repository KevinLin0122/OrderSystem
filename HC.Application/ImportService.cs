using System;
using System.Collections.Generic;
using System.Xml.Linq;
using HC.Core.Models;
using HC.Core.Repository;


namespace HC.Application
{
    public class ImportService
    {
        public static ImportService CreateForEF()
        {
            return new ImportService(new EFOrderRepository());
        }
        public IOrderRepository Repository { get; set; }
        private ImportService(EFOrderRepository repository) { Repository = repository; }

        public List<Product> FindOpenDataFromDb(string name = null)
        {
            return Repository.SelectAll(name);
        }
        public void ImportToDb(List<Product> openDatas)
        {

            openDatas.ForEach(item =>
            {
                Repository.Insert(item);
            });

        }

        private string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();

        }
    }
}
