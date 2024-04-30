import React from 'react';

const Sidebar = () => {
  return (
    <div className="bg-gray-800 h-screen w-64 fixed left-0 top-0 flex flex-col justify-between">
      {/* Contenido del sidebar aquí */}
      <div className="p-4">
        <h2 className="text-white text-lg font-semibold">Sidebar</h2>
        <ul className="mt-4">
          <li className="text-white">Opción 1</li>
          <li className="text-white">Opción 2</li>
          <li className="text-white">Opción 3</li>
        </ul>
      </div>
      <div className="p-4">
        <p className="text-white">© 2024 Todos los derechos reservados</p>
      </div>
    </div>
  );
};

export default Sidebar;
