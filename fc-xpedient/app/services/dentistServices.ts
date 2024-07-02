export interface DentistSideBarResponse{
    dentistImage: string;
    dentistUser: string;
}


export async function getDentistSideBarInfo(): Promise<DentistSideBarResponse> {
    const token = getTokenFromCookie();
    if (!token) {
      throw new Error('Token not found in cookie');
    }
  
    try {
      const response = await fetch('http://localhost:5080/api/userinfo', {
        method: 'GET',
        headers: {
          'Authorization': `Bearer ${token}`,
          'Content-Type': 'application/json',
        },
      });
  
      if (!response.ok) {
        throw new Error('Failed to fetch user info');
      }
  
      return await response.json() as DentistSideBarResponse;
    } catch (error) {
      console.error('An unexpected error occurred:', error);
      throw error;
    }
  }
  