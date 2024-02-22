using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;

namespace LittleMolarApi.Services;

public class DentistService : IDentist{

    // private readonly ApplicationDbContext _context;
    private List<Dentist> _dentist;
    private Dentist dentist;


    // public DentistService(ApplicationDbContext context){
    //     _context = context;
    // }

    public DentistService(){
        _dentist = new List<Dentist>{
            new Dentist(
                id: 1,
                dentistName: "Dentist User",
                dentistLastName: "Dentist Last",
                dentistUser: "Molar12345",
                dentistPassword: "123455",
                dentistEmail: "dentist1@gmail.com",
                dentistAge: 42,
                dentistId: 123313,
                dentistPhone: "45-56-78-90-24"
            )
        };
    }

    public List<Dentist> getAllDentist(){
        return _dentist;
    }

    public void addDentist(Dentist newDentist){
        _dentist.Add(newDentist);
        // throw new NotImplementedException();
    }
}