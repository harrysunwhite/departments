using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace departments.Models
{
    public class DbConnect
    {
        public IConfigurationRoot GetJson(string fileName)
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                  .AddJsonFile(fileName).Build();
        }
    }
}
