using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class PaginationDTO<T>
    {
        private List<T> content;
        private int totalElements;
        private int totalPage;

        public int TotalElements { get => totalElements; set => totalElements = value; }
        public int TotalPage { get => totalPage; set => totalPage = value; }
        public List<T> Content { get => content; set => content = value; }
        public PaginationDTO(int totalByPage, int elements, List<T> contentData)
        {
            totalElements = elements;
            totalPage = elements / totalByPage;
            content = contentData;
        }
    }
}
