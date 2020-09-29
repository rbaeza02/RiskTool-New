using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVC.Client.Extensions.Utilities
{
    public class RewriteUrlTransform : IItemTransform
    {
        CssRewriteUrlTransform tran = new CssRewriteUrlTransform();
        public string Process(string includedVirtualPath, string input)
        {
            var input1 = tran.Process(includedVirtualPath, input);
            var basePath = VirtualPathUtility.ToAbsolute("~");
            
            //if (basePath != "/")
              //  input1 = input1.Replace("url(/Content", string.Format("url({0}/Content", basePath));
          
            //return input1;
#if DEBUG
           return input1;
#else
           // input1 = input1.Replace("url('/Content", string.Format("url('{0}/Content", "MS"));
            input1 = input1.Replace("url(/Content", string.Format("url({0}/Content", basePath));
            return input1;
#endif



        }
    }

}