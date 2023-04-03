using GatitosWebApp.Models;

namespace GatitosWebApp.Services { 
public class GatitoService

{
    private static GatitoService _instance;
    private readonly List<Gatito> _gatitos;

    private GatitoService()
    {
        _gatitos = new List<Gatito>();
    }

    public static GatitoService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GatitoService();
            }
            return _instance;
        }
    }

       

        public List<Gatito> GetAll()
        {
            return _gatitos;
        }

        public Gatito GetById(int id)
        {
            return _gatitos.FirstOrDefault(g => g.Id == id);
        }

        public void Create(Gatito gatito)
        {
            int nextId = _gatitos.Count > 0 ? _gatitos.Max(g => g.Id) + 1 : 1;
            gatito.Id = nextId;
            _gatitos.Add(gatito);
        }

        public void Update(Gatito gatito)
        {
            var existingGatito = GetById(gatito.Id);
            if (existingGatito != null)
            {
                existingGatito.Nombre = gatito.Nombre;
                existingGatito.Raza = gatito.Raza;
                existingGatito.ImagenUrl = gatito.ImagenUrl;
            }
        }

        public void Delete(int id)
        {
            var gatito = GetById(id);
            if (gatito != null)
            {
                _gatitos.Remove(gatito);
            }
        }
    }
}