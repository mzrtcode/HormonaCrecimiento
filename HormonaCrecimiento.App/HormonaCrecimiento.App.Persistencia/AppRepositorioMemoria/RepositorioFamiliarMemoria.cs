using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public class RepositorioFamiliarMemoria : IRepositorioFamiliarMemoria
    {

        List<Familiar> familiares;
        public RepositorioFamiliarMemoria()
        {
            familiares = new List<Familiar>(){
            new Familiar{
            Id=1,
            Nombre="Juan Manuel",
            Apellido="Diaz",
            Documento="10616892335",
            Genero=Genero.Femenino,
            Parentesco="Madre",
            Correo= "54564654",
            Telefono = "310254542",
               },
            new Familiar{
            Id=2,
            Nombre="Ivan",
            Apellido="Tapia",
            Documento="800212421",
            Genero=Genero.Masculino,
            Parentesco="Tio",
            Correo= "54564654",
            Telefono = "310254542",
               }


            };
        }
        public IEnumerable<Familiar> GetAll()
        {
            return familiares;
        }
        public Familiar Add(Familiar familiar)
        {
            
            familiar.Id = familiares.Max(m=> m.Id)+1;
            familiares.Add(familiar);
            return familiar;
        }
        public Familiar Update(Familiar familiar)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int idFamiliar)
        {
            throw new NotImplementedException();
        }
        public Familiar Get(int idFamiliar)
        {
            return familiares.SingleOrDefault(m=> m.Id == idFamiliar);

        }

    }
}