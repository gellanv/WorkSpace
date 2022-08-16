using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSpace.ViewModels.Response
{
    public class GetBlockByIdResponse
    {
            public int Id { get; set; }
            public string ContentHtml { get; set; }
            public int Position { get; set; }
    }
}
