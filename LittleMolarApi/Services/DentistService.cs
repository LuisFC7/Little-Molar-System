using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;

namespace LittleMolarApi.Services;

public class DentistService : IDentist{

    private readonly ApplicationDbContext _context;
    private List<Dentist> _dentist;
    private Dentist dentist;


    public DentistService(ApplicationDbContext context){
        _context = context;
    }

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
        try{
           return _context.Dentist.ToList();
        }
        catch (Exception ex){
            throw ex;
        }

    }

    public void addDentist(Dentist newDentist){
        _context.Dentist.Add(newDentist);
        _context.SaveChanges();
        // _dentist.Add(newDentist);
        // throw new NotImplementedException();
    }

    public void updateDentist(Dentist dentist){

        var identify = _dentist.FirstOrDefault(i => i.id == dentist.id);
        if(identify != null){
            identify.dentistName = dentist.dentistName;
            identify.dentistLastName = dentist.dentistLastName;
            identify.dentistUser = dentist.dentistUser;
            identify.dentistPassword = dentist.dentistPassword;
            identify.dentistEmail = dentist.dentistEmail;
            identify.dentistAge = dentist.dentistAge;
            identify.dentistId = dentist.dentistId;
            identify.dentistPhone = dentist.dentistPhone;
        }else{
            throw new InvalidOperationException($"Dentist not found.");
        }
    }

   public void deleteDentist(int dentistId){

    var dentistDelete = _dentist.FirstOrDefault(d => d.id == dentistId);
    
    if(dentistDelete != null){
        _dentist.Remove(dentistDelete);
    }

   }
}