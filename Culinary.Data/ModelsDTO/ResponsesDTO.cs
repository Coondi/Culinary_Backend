using System;
using System.Collections.Generic;
using System.Text;

namespace Culinary.Data.ModelsDTO
{
    public class ResponsesDTO<T> where T : BaseModelDTO
    {
        public List<T> Object { get; set; }
        public bool ErrorOccured => Errors.Count > 0;
        public List<string> Errors { get; set; }

        public ResponsesDTO()
        {
            Errors = new List<string>();
        }
    }
}
