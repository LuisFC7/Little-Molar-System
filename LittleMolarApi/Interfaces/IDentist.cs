using LittleMolarApi.Models;

namespace LittleMolarApi.Interfaces;

public interface IDentist{

    //Methods for IDentisi
    void addDentist(Dentist newDentist);
    List<Dentist> getAllDentist();
    // Dentist getDentistById(int dentistId);
    // Dentist updateDentist(int dentistId);
    // void deleteDentist(int dentistId);
}