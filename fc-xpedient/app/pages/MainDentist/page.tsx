"use client";

import React, { useState, useEffect } from 'react';
import Sidebar from '../../components/SideBar/SideBar'; 
import { getDentistSideBarInfo, DentistSideBarResponse } from '../../services/dentistServices';

const Page: React.FC = () => {
  const [userInfo, setUserInfo] = useState<DentistSideBarResponse | null>(null);

  useEffect(() => {
    // Función para obtener la información del usuario después del montaje del componente
    const fetchUserInfo = async () => {
      try {
        const userInfoData = await getDentistSideBarInfo();
        setUserInfo(userInfoData);
      
      } catch (error) {
        console.error('Error al obtener la información del usuario:', error);
      }
    };

    fetchUserInfo(); // Llama a la función para obtener la información del usuario
  }, []);

  return (
    <div>
      {/* Renderiza el componente Sidebar y pasa los datos del usuario como props */}
      {/* userInfo && <Sidebar userImage={"sddss"} userName={"ELLKS"} /> */}
      {/* {userInfo && <Sidebar userImage={userInfo.dentistImage} userName={userInfo.dentistUser} />} */}
      {/* Contenido de tu página */}
    </div>
  );
}

export default Page;
