#include <iostream>


using namespace std;

class Persona
{
    public:
        string nombre;
        int NumeroTelefono;
        string email;
        virtual void ComparPaseEstacionamiento()=0;
};

class Direccion
{
    public:
        string calle;
        string ciudad;
        string estado;
        int codigoPostal;
        string pais;

        void Validar();
        void OuputAsLabel();
        Direccion();

};

class Estudiante : public Persona
{
    public:
        int numeroEstudiante;
        int promedio;

        void esElegibleParaInscribirse();
        void obtenerSeminariosObtenidos();
        Estudiante();
        void ComparPaseEstacionamiento();


};

class Profesor : public Persona
{
    public:
        int salario;
        Profesor();
        void ComparPaseEstacionamiento();

};

Direccion::Direccion()
{
    cout <<"Digite una direccion:\nIngrese la calle: ";
    cin >> calle;

    cout<<"\nIngrese la ciudad: ";
    cin >> ciudad;

    cout <<"\nIngrese el estado: ";
    cin >> estado;

    cout << "\nIngrese el codigo postal: ";
    cin >> codigoPostal;

    cout << "\nIngrese el pais: ";
    cin >> pais;
}

Profesor::Profesor()
{
    cout << "\n\nRegistro de Profesor:\nIngrese su Nombre: ";
    cin >> nombre;

    cout << "\nIngrese su numero de telefono: ";
    cin >> NumeroTelefono;

    cout << "\nIngrese su Correo Electronico: ";
    cin >> email;

    cout <<"\nIngrese su salario: ";
    cin >> salario;
}

Estudiante::Estudiante()
{
    cout << "\n\nRegistro de Estudiante:\nIngrese su Nombre: ";
    cin >> nombre;

    cout << "\nIngrese su numero de telefono: ";
    cin >> NumeroTelefono;

    cout << "\nIngrese su Correo Electronico: ";
    cin >> email;

    cout << "\nIngrese Numero de estudiante: ";
    cin >> numeroEstudiante;

    cout << "\nIngrese el promedio del estudiante: ";
    cin >> promedio;
}


void Estudiante::ComparPaseEstacionamiento()
{
    cout << "El Estudiante NO tiene pase de estacionamiento:";
}

void Profesor::ComparPaseEstacionamiento()
{
    cout << "El Profesor SI tiene pase de estacionamiento:";
}

void Estudiante::esElegibleParaInscribirse()
{
    cout << "El Estudiante Si Puede Inscribirse:";
}

void Estudiante::obtenerSeminariosObtenidos()
{
    cout << "El Estudiante NO tiene seminarios:";
}

void Direccion::Validar()
{
    cout << "Direccion Valida:";
}

void Direccion::OuputAsLabel()
{
    cout << "OuputAsLabel:";
}



int main()
{
    Direccion *dir = new Direccion();
    Profesor *prof = new Profesor();
    Estudiante *est = new Estudiante();

    cout << "Direccion Ingresada"<<endl;
    cout << "Calle: "<<dir->calle <<endl;
    cout << "Ciudad: "<<dir->ciudad<<endl;
    cout << "Estado: "<<dir->estado<<endl;
    cout << "Codigo Postal: "<<dir->codigoPostal<<endl;
    cout << "Pais: "<<dir->pais<<endl;

    cout << "\nEstudiante Ingresado"<<endl;
    cout << "Nombre: "<<est->nombre<<endl;
    cout << "Numero Telefonico: "<<est->NumeroTelefono<<endl;
    cout << "Email: "<<est->email<<endl;
    cout << "Numero Estudiantil: "<<est->numeroEstudiante<<endl;
    cout << "Promedio: "<<est->promedio<<endl;

    cout << "\nProfesor Ingresado"<<endl;
    cout << "Nombre: "<<prof->nombre<<endl;
    cout << "Numero Telefonico: "<<prof->NumeroTelefono<<endl;
    cout << "Email: "<<prof->email<<endl;
    cout << "Promedio: "<<prof->salario<<endl;

    return 0;
}
