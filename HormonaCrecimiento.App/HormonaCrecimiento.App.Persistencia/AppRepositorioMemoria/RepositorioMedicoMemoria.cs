using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HormonaCrecimiento.App.Dominio;

namespace HormonaCrecimiento.App.Persistencia
{
    public class RepositorioMedicoMemoria : IRepositorioMedicoMemoria
    {

        List<Medico> medicos;
        public RepositorioMedicoMemoria()
        {
            medicos = new List<Medico>(){
            new Medico{
            Id=1,
            Nombre="Diana",
            Apellido="Muñoz",
            Documento="10616892335",
            Genero=Genero.Femenino,
            Especializacion=Especializacion.Endocrino,
            Codigo= "54564654",
            Telefono = "310254542",
            RegistroRetThus = "98232212"
               },
            new Medico{
            Id=2,
            Nombre="Marcos",
            Apellido="Diaz",
            Documento="800212421",
            Genero=Genero.Masculino,
            Especializacion=Especializacion.Pediatra,
            Codigo= "54564654",
            Telefono = "310254542",
            RegistroRetThus = "98232212"
               }


            };
        }
        public IEnumerable<Medico> GetAll()
        {
            return medicos;
        }
        public Medico Add(Medico medico)
        {
            
            medico.Id = medicos.Max(m=> m.Id)+1;
            medicos.Add(medico);
            return medico;
        }
        public Medico Update(Medico medico)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int idMedico)
        {
            throw new NotImplementedException();
        }
        public Medico Get(int idMedico)
        {
            return medicos.SingleOrDefault(m=> m.Id == idMedico);

        }

    }
}