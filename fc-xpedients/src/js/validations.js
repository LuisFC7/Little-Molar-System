function emailValidation() {
    var email = document.getElementById("email").value;
    var mensaje = document.getElementById("mensaje");
  
    // Expresión regular para validar un correo electrónico
    var regex = /^[a-zA-Z0-9._%+-]+@(?:gmail|yahoo|hotmail|outlook)\.(?:com|es|net|org)$/;
  
    // Verificar si el correo electrónico cumple con la expresión regular
    if (regex.test(email)) {
      mensaje.textContent = "Correo electrónico válido";
      mensaje.classList.remove("text-red-500");
      mensaje.classList.add("text-green-500");
    } else {
      mensaje.textContent = "Correo electrónico inválido";
      mensaje.classList.remove("text-green-500");
      mensaje.classList.add("text-red-500");
    }
}