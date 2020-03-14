const { Given, When, Then } = require('cucumber');
var chai = require('chai')
let chaiHttp = require('chai-http');
let should = chai.should();
chai.use(chaiHttp);
expect = chai.expect


Given('O paciente acessa o guia médico da unimed', async function () {
    chai.request('https://api.unimed.coop.br')
    .get('/guia-medico/v2/estados/') // endpoint que vamos testar
                .end((err, res) => { // testes a serem realizados
                    res.should.have.status(200); // verificando se o retorno e um status code 200
                    res.should.be.an('Object'); // Verificando se o retorno e um array
                    res.body[18].should.include({ sigla: 'RJ', nome: 'Rio de Janeiro' })
                });
    
    chai.request('https://api.unimed.coop.br')
    .get('/unimed/v3/unimeds/')
        .end((err,res) => {
            res.should.have.status(200);
            res.should.be.an('Object');
        });
    
    chai.request('https://api.unimed.coop.br')
    .get('/guia-medico/v2/estados/RJ/cidades')
        .end((err,res) => {
            res.should.have.status(200);
            res.should.be.an('Object');
            res.body[67].should.include({ cdCidade: '3304557', nome: 'Rio de Janeiro' })
        });

    chai.request('https://api.unimed.coop.br')
    .get('/guia-medico/v2/cidade/3304557/unimed')
        .end((err,res) => {
            res.should.have.status(200);
            res.should.be.an('Object');
            res.body[0].should.include({
                cdUnimed: 37,
                cdCidadeUnimed: 3304557,
                nmUnimed: 'UNIMED RIO',
                nmUnimedCombo: 'UNIMED RIO',
                complemento: null,
                latitude: -23.006483,
                longitude: -43.311274
            })
        });
        
});  

When('O paciente pesquisa pela cidade do Rio de Janeiro', async function () {
    chai.request('https://api.unimed.coop.br')
    .get('/unimed/v3/unimeds/37')
        .end((err,res) => {
            res.should.have.status(200);
            res.should.be.an('Object');
            res.body.should.include({
                "cdUnimed":37,
                "nmUnimed":"UNIMED RIO",
                "telefone":"(21) 3139-7999",
                "site":"www.unimedrio.com.br",
                "latitude":-23.006483,
                "longitude":-43.311274,
                "uf":"RJ",
                "cdCidade":"3304557",
                "cidade":"RIO DE JANEIRO",
                "bairro":"BARRA DA TIJUCA",
                "endereco":"AVENIDA ARMANDO LOMBARDI, 400 - LOJAS 101 A 105",
                "cep":22640000,
                "nroANS":393321,
                "dsTipoPrestador":"SINGULAR"
            })
        });
    
    
});

Then('Os resultados dos médicos do Rio de Janeiro são apresentados', async function () {
    chai.request('https://api.unimed.coop.br')
    .post('/guia-medico/v2/prestadores')
    .send(
        {
            "filters": [
                {
                    "field": "CD_UNIMED",
                    "value": 37
                },
                {
                    "field": "SEARCH",
                    "value": "Rio de Janeiro"
                }
            ],
            "page": 0,
            "geo": {
                "latitude": -23.006483,
                "longitude": -43.311274
            },
            "limitarPorAreaDeAcao": false,
            "type": "SIMPLE",
            "order": "DISTANCIA_ASC"
        }
    )
        .end((err,res) => {
            res.should.have.status(202);
            res.should.be.an('Object');
            res.text.should.include("nmEstado","Rio de Janeiro","nmCidade","Rio de Janeiro","especialidades")
            //res.body.guiaMedicoPrestador.should.have.members({ prestador.especialidades })
        });

});