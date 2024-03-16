using LittleMolarApi.DTO;
using LittleMolarApi.Models;

namespace LittleMolarApi.Interfaces;

public interface IDentist{

    //Methods for IDentisi
    Task addDentist(DentistDto newDentist);
    // void addDentist(DentistDto newDentist);

    // Read all the dentist list
    List<Dentist> getAllDentist();

    bool usernameDentistExist(string username);
    bool emailDentistExist(string email);


    // Update data Dentist using idk
    // void updateDentist(Dentist dentist);

    // void deleteDentist(int dentistId);

}