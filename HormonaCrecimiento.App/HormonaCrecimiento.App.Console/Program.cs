using System;
using HormonaCrecimiento.App.Dominio;
using HormonaCrecimiento.App.Persistencia;
using ConsoleTables;


namespace HormonaCrecimiento.App.Consola;
class Program
{
    private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
    private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
    private static IRepositorioFamiliar _repoFamiliar = new RepositorioFamiliar(new Persistencia.AppContext());
    static void Main(string[] args)
    {

        mainMenu();
        //AsignarMedico(); //IdPaciente, IdMedico
        //AsignarFamiliar(); //IDPaciente, IDFamiliar
        //AsignarHistoria(); //IdPaciente, IdHistoria
        //ModificarPaciente(); 
        //EliminarPaciente(); idpaciente
        
    }


    /*
    ********************************      Metodos CRUD para PACIENTE     ********************************
    */
    private static void AddPaciente()
    {
        string nombre, apellido, documento, direccion, ciudad, genero;
        float latitud, longitud;
        DateTime fechaNacimiento;

        //PEDIR NOMBRE
        while (true)
        {
            Console.Write("Nombres: ");
            nombre = Console.ReadLine();

            if (!string.IsNullOrEmpty(nombre)) break;
            else continue;
        }

        //PEDIR APELLIDO
        while (true)
        {
            Console.Write("Apellidos: ");
            apellido = Console.ReadLine();

            if (!string.IsNullOrEmpty(apellido)) break;
            else continue;
        }

        //PEDIR DOCUMENTO
        while (true)
        {
            Console.Write("Documento: ");
            documento = Console.ReadLine();

            if (!string.IsNullOrEmpty(documento)) break;
            else continue;
        }

        //PEDIR DIRECCION
        while (true)
        {
            Console.Write("Direccion: ");
            direccion = Console.ReadLine();

            if (!string.IsNullOrEmpty(direccion)) break;
            else continue;
        }

        //PEDIR GENERO
        while (true)
        {
            Console.Write("Genero: Masculino(m) Femenino(f) ");
            genero = Console.ReadLine();

            if (genero == "m" || genero == "f") break;
            else continue;
        }


        //PEDIR LATITUD
        while (true)
        {
            Console.Write("Latitud: ");

            try
            {
                latitud = Single.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                continue;
            }
        }

        //PEDIR LONGITUD
        while (true)
        {
            Console.Write("Longitud: ");

            try
            {
                longitud = Single.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                continue;
            }
        }

        //PEDIR CIUDAD
        while (true)
        {
            Console.Write("Ciudad: ");
            ciudad = Console.ReadLine();

            if (!string.IsNullOrEmpty(ciudad)) break;
            else continue;

        }

        //PEDIR FECHANACIMIENTO
        while (true)
        {
            Console.Write("Fecha de Nacimiento (dd/mm/YYYY): ");

            try
            {
                fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                break;
            }
            catch
            {
                continue;
            }
        }


        //AÑADIR PACIENTE

        var paciente = new Paciente
        {
            Nombre = nombre,
            Apellido = apellido,
            Documento = documento,
            Direccion = direccion,
            Latitud = latitud,
            Longitud = longitud,
            Ciudad = ciudad,
            FechaNacimiento = fechaNacimiento

        };

        if (genero == "m") paciente.Genero = Genero.Masculino;
        else paciente.Genero = Genero.Femenino;


        _repoPaciente.AddPaciente(paciente);
        Console.WriteLine("\n :: Paciente Agregado ::");
        Console.ReadKey();




    }

    private static bool BuscarPaciente(int idPaciente)
    {
        var paciente = _repoPaciente.GetPaciente(idPaciente);

        //TODO *************************************************
        //Traer el nombre de medico y de familiar
        //Traer el numero de telefono de familiar
        //Traer el diagnostico de HistoriaClinica



        if (paciente != null)
        {


            var table = new ConsoleTable("id", "Nombre", "Documento", "Apellido", "FechaNacim", "Ciudad", "Medico", "Familiar", "Telefono", "Diagnostico");

            table.AddRow(
                paciente.Id, paciente.Nombre, paciente.Documento, paciente.Apellido,
                String.Format("{0:MM/dd/yyyy}", paciente.FechaNacimiento), paciente.Ciudad,
                ":IMPLEMENTAR:", ":IMPLEMENTAR:", ":IMPLEMENTAR:", ":IMPLEMENTAR:"
                );

            table.Options.EnableCount = false;
            table.Write();
            return true;
        }
        return false;

    }

    private static void MostrarPacientes()
    {

        var pacientes = _repoPaciente.GetAllPacientes();
        var table = new ConsoleTable("id", "Documento", "Nombre", "Apellido", "Fecha Nacimiento");

        foreach (var paciente in pacientes)
        {
            table.AddRow(paciente.Id, paciente.Documento, paciente.Nombre, paciente.Apellido, String.Format("{0:MM/dd/yyyy}", paciente.FechaNacimiento));
        }

        table.Options.EnableCount = false;
        table.Write();
        Console.ReadKey();
    }

    private static void ModificarPaciente(Paciente paciente)
    {
        _repoPaciente.UpdatePaciente(paciente);
    }

    private static void EliminarPaciente(int idPaciente)
    {
        _repoPaciente.DeletePaciente(idPaciente);
    }

    private static void AsignarMedico(int idPaciente, int idMedico)
    {

        var paciente = _repoPaciente.SetMedico(idPaciente, idMedico);
    }

    private static void AsignarFamiliar(int idPaciente, int idFamiliar)
    {
        var paciente = _repoPaciente.SetFamiliar(idPaciente, idFamiliar);
    }

    private static void AsignarHistoria(int idPaciente, int idHistoriaClinica)
    {
        var paciente = _repoPaciente.SetHistoriaClinica(idPaciente, idHistoriaClinica);
    }


    /*
    ********************************      Metodos CRUD para MEDICO     ********************************
    */
    private static void AddMedico()
    {

        string nombre, apellido, documento, genero, especializacion, codigo, telefono, registrorethus;

        //PEDIR NOMBRE
        while (true)
        {
            Console.Write("Nombres: ");
            nombre = Console.ReadLine();

            if (!string.IsNullOrEmpty(nombre)) break;
            else continue;
        }

        //PEDIR APELLIDO
        while (true)
        {
            Console.Write("Apellidos: ");
            apellido = Console.ReadLine();

            if (!string.IsNullOrEmpty(apellido)) break;
            else continue;
        }

        //PEDIR DOCUMENTO
        while (true)
        {
            Console.Write("Documento: ");
            documento = Console.ReadLine();

            if (!string.IsNullOrEmpty(documento)) break;
            else continue;
        }

        //PEDIR GENERO
        while (true)
        {
            Console.Write("Genero: Masculino(m) Femenino(f) ");
            genero = Console.ReadLine();

            if (genero == "m" || genero == "f") break;
            else continue;
        }

        //PEDIR ESPECIALIZACION
        while (true)
        {
            Console.Write("Especializacion Endocrino(e) Pediatra(p): ");
            especializacion = Console.ReadLine();

            if (especializacion == "e" || especializacion == "p") break;
            else continue;
        }

        //PEDIR CODIGO
        while (true)
        {
            Console.Write("Codigo: ");
            codigo = Console.ReadLine();

            if (!string.IsNullOrEmpty(codigo)) break;
            else continue;
        }

        //PEDIR TELFONO
        while (true)
        {
            Console.Write("Telefono: ");
            telefono = Console.ReadLine();

            if (!string.IsNullOrEmpty(telefono)) break;
            else continue;
        }

        //PEDIR REGISTRO RETHUS
        while (true)
        {
            Console.Write("Registro Rethus: ");
            registrorethus = Console.ReadLine();

            if (!string.IsNullOrEmpty(registrorethus)) break;
            else continue;
        }



        //AÑADIR MEDICO
        var medico = new Medico
        {
            Nombre = nombre,
            Apellido = apellido,
            Documento = documento,
            Codigo = codigo,
            Telefono = telefono,
            RegistroRetThus = registrorethus
        };

        if (genero == "m") medico.Genero = Genero.Masculino;
        else medico.Genero = Genero.Femenino;

        if (especializacion == "e") medico.Especializacion = Especializacion.Endocrino;
        else medico.Especializacion = Especializacion.Pediatra;


        _repoMedico.AddMedico(medico);

        Console.WriteLine("\n :: Medico Agregado ::");
        Console.ReadKey();
    }

    private static void BuscarMedico(int idMedico)
    {
        var medico = _repoMedico.GetMedico(idMedico);
        Console.WriteLine("Nombre: " + medico.Nombre + " Apellido: " + medico.Apellido);
    }

    private static void MostrarMedicos()
    {
        var medicos = _repoMedico.GetAllMedicos();
        foreach (var medico in medicos)
        {
            Console.WriteLine("Nombre: " + medico.Nombre + " Apellido:" + medico.Apellido);
        }
    }

    private static void ModificarMedico(Medico medico)
    {
        _repoMedico.UpdateMedico(medico);
    }

    private static void EliminarMedico(int idMedico)
    {
        _repoMedico.DeleteMedico(idMedico);
    }


    /*
    ********************************      Metodos CRUD para FAMILIAR     ********************************
    */



    private static void AddFamiliar()
    {
        string nombre, apellido, documento, genero, parentesco, correo, telefono;

        //PEDIR NOMBRE
        while (true)
        {
            Console.Write("Nombres: ");
            nombre = Console.ReadLine();

            if (!string.IsNullOrEmpty(nombre)) break;
            else continue;
        }

        //PEDIR APELLIDO
        while (true)
        {
            Console.Write("Apellidos: ");
            apellido = Console.ReadLine();

            if (!string.IsNullOrEmpty(apellido)) break;
            else continue;
        }

        //PEDIR DOCUMENTO
        while (true)
        {
            Console.Write("Documento: ");
            documento = Console.ReadLine();

            if (!string.IsNullOrEmpty(documento)) break;
            else continue;
        }

        //PEDIR GENERO
        while (true)
        {
            Console.Write("Genero: Masculino(m) Femenino(f) ");
            genero = Console.ReadLine();

            if (genero == "m" || genero == "f") break;
            else continue;
        }

        //PEDIR PARENTESCO
        while (true)
        {
            Console.Write("Parentesco: ");
            parentesco = Console.ReadLine();

            if (!string.IsNullOrEmpty(parentesco)) break;
            else continue;
        }
        //PEDIR CORREO
        while (true)
        {
            Console.Write("Correo: ");
            correo = Console.ReadLine();

            if (!string.IsNullOrEmpty(correo)) break;
            else continue;
        }

        //PEDIR TELEFONO
        while (true)
        {
            Console.Write("Telefono: ");
            telefono = Console.ReadLine();

            if (!string.IsNullOrEmpty(telefono)) break;
            else continue;
        }


        var familiar = new Familiar
        {
            Nombre = nombre,
            Apellido = apellido,
            Documento = documento,
            Parentesco = parentesco,
            Correo = correo,
            Telefono = telefono

        };

        if (genero == "m") familiar.Genero = Genero.Masculino;
        else familiar.Genero = Genero.Femenino;
        _repoFamiliar.AddFamiliar(familiar);

        Console.WriteLine("\n :: Familiar Agregado ::");
        Console.ReadKey();

    }

    private static void BuscarFamiliar(int idFamiliar)
    {
        var familiar = _repoFamiliar.GetFamiliar(idFamiliar);
        Console.WriteLine("Nombre: " + familiar.Nombre + " Apellido: " + familiar.Apellido);
    }

    private static void MostrarFamiliares()
    {
        var familiares = _repoFamiliar.GetAllFamiliares();
        foreach (var familiar in familiares)
        {
            Console.WriteLine("Nombre: " + familiar.Nombre + " Apellido:" + familiar.Apellido);
        }
    }

    private static void ModificarFamiliar(Familiar familiar)
    {
        _repoFamiliar.UpdateFamiliar(familiar);
    }

    private static void EliminarFamiliar(int idFamiliar)
    {
        _repoFamiliar.DeleteFamiliar(idFamiliar);
    }





    private static void mainMenu()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("************ HORMONA DE CRECIMIENTO ************");
            Console.WriteLine("\n 1. Registrar paciente");
            Console.WriteLine(" 2. Registrar medico");
            Console.WriteLine(" 3. Registrar familiar");
            Console.WriteLine(" 4. Consultar todos los pacientes");
            Console.WriteLine(" 5. Consultar paciente");
            Console.WriteLine(" 6. Salir\n");
            Console.Write("Ingrese una opcion: ");


            try
            {
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {

                    case 1:
                        AddPaciente();
                        continue;

                    case 2:
                        AddMedico();
                        continue;
                    case 3:
                        AddFamiliar();
                        continue;
                    case 4:
                        MostrarPacientes();
                        continue;
                    case 5:
                        Console.Write(" ->Ingrese el ID del paciente: ");
                        try
                        {
                            int id = int.Parse(Console.ReadLine());
                            if (BuscarPaciente(id) == false) Console.WriteLine("\n ::Paciente no encontrado:: ");
                            Console.ReadKey();
                            continue;
                        }
                        catch
                        {
                            Console.WriteLine("El ID debe ser un entero");
                            continue;
                        }
                    default:
                        Environment.Exit(0);
                        break;

                }

            }
            catch
            {
                Console.WriteLine(" ::Opcion Invalida:: ");
                Console.Clear();
                continue;
            }
        }

    }

}