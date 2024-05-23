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
            return await response.json() as LoginResponse;
        } else {
            if(response.statusText=== "Bad Request")
                throw new Error('Inicio de sesión incorrecto, usuario o contraseña incorrecto');
            throw new Error('Inicio de sesión incorrecto: ' + response.statusText);
        }
    } catch (error) {
        console.error('Ha ocurrido un error inesperado:', error);
        throw error;
    }
}
