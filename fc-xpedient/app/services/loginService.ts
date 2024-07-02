import { getDentistSideBarInfo } from "./dentistServices"

export interface LoginResponse {
    token: string;
    message: string;
}

export async function login(identifier: string, password: string): Promise<LoginResponse> {
    const loginData = {
        identifier: identifier,
        password: password,
    };

    try {
        const response = await fetch('http://localhost:5080/api/Dentist/dentistLogin', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(loginData),
        });

        if (response.ok) {

            //Canbios agregados
            const loginResponse = await response.json() as LoginResponse;
            document.cookie = `token=${loginResponse.token}; path=/; secure`;
            // return await response.json() as LoginResponse;
            // const dentistInfo = await getDentistSideBarInfo();
            return loginResponse;
        } else {
            if(response.statusText === "Bad Request")
                throw new Error('Inicio de sesión incorrecto, usuario o contraseña incorrecto');
            throw new Error('Inicio de sesión incorrecto: ' + response.statusText);
        }
    } catch (error) {
        console.error('Ha ocurrido un error inesperado:', error);
        throw error;
    }
}
