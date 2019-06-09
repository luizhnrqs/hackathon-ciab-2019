function carregarSplash(){
    setTimeout(() => {
        window.location.href = window.location.pathname.replace("Cadastro/", "Cadastro/Cadastro1");
    }, 2500);
}

    // const EnviarFoto = async (foto) => {
    //     const urlBase = "http://localhost:27512";

    //     const url = urlBase + '/api/cadastro';

    //     const response = await fetch(url, {
    //       method: 'POST',
    //       body: foto, // string or object
    //       headers:{
    //         'Content-Type': 'application/json'
    //       }
    //     });
    //     const myJson = await response.json(); //extract JSON from the http response
    //     // do something with myJson

    //     return myJson;
    // }

function EnviarFoto(foto) {

    var formData = new FormData();
    //var totalFiles = document.getElementById("FileUpload").files.length;

    for (var i = 0; i < foto.length; i++) {
        var file = document.getElementById("photo").files[i];

        formData.append("photo", file);
        //formData.append("guid", theGuid);
    }

    $.ajax({
        type: 'post',
        url: 'https://decision-api.azurewebsites.net/api/cadastro',
        data: formData,
        dataType: 'json',
        contentType: 'multipart/encrypted',
        processData: false,
        success: function (response) {
            //alert('succes!!');
            window.location.href = "Cadastro2";
        },
        error: function (error) {
            alert(error);
        }
    });

}

function TirarSelf(foto) {
    window.location.href = "Cadastro4";
}

function CapturarDados(id){
    const userAction = async () => {
        const response = await fetch('http://example.com/movies.json');
        const myJson = await response.json(); //extract JSON from the http response
        // do something with myJson
      }
}