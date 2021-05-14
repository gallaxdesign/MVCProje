﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterList();
        void WriterAdd(Writer writer);
        Writer GetByID(int id);

        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
