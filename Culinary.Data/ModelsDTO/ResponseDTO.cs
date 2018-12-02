using System;
using System.Collections.Generic;
using System.Text;

namespace Culinary.Data.ModelsDTO
{
    public class ResponseDTO<T> where T : BaseModelDTO
    {
        public T Object { get; set; }
        public bool ErrorOccured => Errors.Count > 0;
        public List<string> Errors { get; set; }

        public ResponseDTO()
        {
            Errors = new List<string>();
        }

    }
}
