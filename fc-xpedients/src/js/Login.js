document.getElementById("buttonEntrar").onclick = function(){
  login();
}

function login() {

  var emailInput = document.getElementById('email') as HTMLInputElement;
  var passwordInput = document.getElementById('password') as HTMLInputElement;

  var identifier = emailInput.value;
  var password = passwordInput.value;

  console.log(identifier);
  console.log(password);

  fetch('http://localhost:5080/api/Dentist/dentistLogin', {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json'
      },
      body: JSON.stringify({
          identifier: identifier,
          password: password
      })
  })
  .then(response => {
      if (response.ok) {
          alert('Inicio de sesión exitoso');
          return response.json();
      } else {
        throw new Error('Error al iniciar sesión');
      }
  })
  .then(data => {
  if (data && data.token) {
      var token = data.token;
      console.log('Token:', token);
  } else {
      throw new Error('La respuesta del servidor no contiene un token válido');
  }
  })
  .catch(error => {
      console.error('Error:', error);
      alert('Error de conexión');
  });
}