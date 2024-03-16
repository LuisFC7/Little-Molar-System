using LittleMolarApi.DTO;
using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;

namespace LittleMolarApi.Services;

public class DentistService : IDentist{

    private readonly ApplicationDbContext _context;

    public DentistService(ApplicationDbContext context){
        _context = context;
    }

    public List<Dentist> getAllDentist(){
        try{
           return _context.Dentist.ToList();
        }
        catch (Exception ex){
            throw ex;
        }
    }

    // public void addDentist(DentistDto newDentistDto){

    //     var newDentist = new Dentist(
    //         newDentistDto.dentistName,
    //         newDentistDto.dentistLastName,
    //         newDentistDto.dentistUser,
    //         newDentistDto.dentistPassword,
    //         newDentistDto.dentistEmail,
    //         newDentistDto.dentistAge,
    //         newDentistDto.dentistId,
    //         newDentistDto.dentistPhone
    //     );
    //     _context.Dentist.Add(newDentist);
    //     _context.SaveChanges();
    // }

    public async Task addDentist(DentistDto newDentistDto){

        var newDentist = new Dentist(
            newDentistDto.dentistName,
            newDentistDto.dentistLastName,
            newDentistDto.dentistUser,
            newDentistDto.dentistPassword,
            newDentistDto.dentistEmail,
            newDentistDto.dentistAge,
            newDentistDto.dentistId,
            newDentistDto.dentistPhone
        );
        _context.Dentist.Add(newDentist);
        await _context.SaveChangesAsync();
    }


    //Methods for knowing if the user or email have been registered
    public bool usernameDentistExist(string username){
        return _context.Dentist.Any(u => u.dentistUser == username);
    }

    public bool emailDentistExist(string email){
        return _context.Dentist.Any(u => u.dentistEmail == email);
    }

    // public void updateDentist(Dentist dentist){

    //     var identify = _dentist.FirstOrDefault(i => i.id == dentist.id);
    //     if(identify != null){
    //         identify.dentistName = dentist.dentistName;
    //         identify.dentistLastName = dentist.dentistLastName;
    //         identify.dentistUser = dentist.dentistUser;
    //         identify.dentistPassword = dentist.dentistPassword;
    //         identify.dentistEmail = dentist.dentistEmail;
    //         identify.dentistAge = dentist.dentistAge;
    //         identify.dentistId = dentist.dentistId;
    //         identify.dentistPhone = dentist.dentistPhone;
    //     }else{
    //         throw new InvalidOperationException($"Dentist not found.");
    //     }
    // }

//    public void deleteDentist(int dentistId){

//     var dentistDelete = _dentist.FirstOrDefault(d => d.id == dentistId);
    
//     if(dentistDelete != null){
//         _dentist.Remove(dentistDelete);
//     }

//    }
}