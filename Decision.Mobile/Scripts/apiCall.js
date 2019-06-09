function carregarSplash(){
    setTimeout(() => {
        window.location.href = window.location.pathname.replace("index", "cadastro1");
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

    function EnviarFoto(foto){
        const urlBase = "http://localhost:27512";

        const url = urlBase + '/api/cadastro';

        var formData = new FormData();

        formData.append("arquivo", foto);

        $.ajax({
            url: url,
            type: 'POST',
            data: formData,
            // async: false,
            headers: {
                'Content-Type': 'multipart/encrypted'
            },
            dataType: 'json',
            success: function (e) {
              alert("success");
            },
            error: function (e){
                alert("erro " + e);
            }
        }).done(function(msg){
            alert('done');
          });
        // $.ajax({
        //     url: url,
        //     type: 'GET',
        //     headers: {
        //         'Content-Type': 'application/json'
        //     },
        //     dataType: 'json',
        //     success: function (data) {
        //       alert(data);
        //     },
        //     error: function (data){
        //         alert("erro " + data);
        //     }
        // }).done(function(msg){
        //     alert('done');
        //   });
    }

function CapturarDados(id){
    const userAction = async () => {
        const response = await fetch('http://example.com/movies.json');
        const myJson = await response.json(); //extract JSON from the http response
        // do something with myJson
      }
}