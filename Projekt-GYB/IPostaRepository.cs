using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_GYB
{
    interface ICsomagRepository
    {
        List<Posta> FindAll();
        List<Posta> FindAllByNameLike(string name);
        Posta FindById(int id);
    }
}