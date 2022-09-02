<template>
  <div id="produtos">
        <h1>Produtos</h1>
            <table id="tabelaProdutos">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Preco</th>
                        <th>Estoque</th>
                        <th>Botoes</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="produto in produtos" :key="produto.id">
                        <td><button id="nomeProd">{{produto.nome}}</button></td>
                        <td>{{produto.preco}}</td>
                        <td>{{produto.estoque}}</td>
                        <td id="botoestab"><button class="edit">Editar</button><button class="delete">Excluir</button></td>
                    </tr>
                </tbody>
            </table>
      </div>
</template>

<script>
export default {
    name: 'TabelaProdutos',
    data(){
        return{
            produtos: []
        }
    },
    methods:{
        async getProdutos(){
            const req = await fetch("http://localhost:3000/Produtos");
            const data = await req.json();
            
            for(var i=0; i<data.length; i++)
            {
                this.produtos.push(data[i]);
            }
        }
    },
    mounted(){
        this.getProdutos();
    }
}
</script>

<style scoped>
    #produtos{
      background: #222;
      position:absolute;
      top: 50%;
      left: 50%;
      transform: translate(-50%,-50%);
      width: 70%;
      height: 70%;
      border-radius: 10px;
    }
    #produtos h1{
        margin: 10px;
        text-align: center;
        color: white;
    }
    #tabelaProdutos{
        margin: auto;
        position:relative;
        width: 95%;
    }
    table{
        table-layout: fixed;
        border-collapse: collapse;
    }
    th, td, tr {
        border: 1px solid white ;
        color: white;
        text-align: center;
        overflow: hidden;
        text-overflow: clip;
    }
    #botoestab{
        height: 30px;
        width: 200px;
    }
    #botoestab button{
        height: 100%;
        width: 50%;
        border: none;
    }

    #botoestab .edit{
        border: -1px;
        background-color: #fcba03;
        color: white;
        text-align: center;
        transition: .5s;
    }
    #botoestab .delete{
        background-color: red;
        color: white;
        text-align: center;
        transition: .5s;
    }
    #botoestab button:hover{
        font-size: 18px;
    }
    #nomeProd{
        color: white;
        transition: .5s;
        border:none;
        background:none;
        outline:none;
        font-size: 16px; 
    }
    #nomeProd:hover{
        color: #fcba03;
        font-size: 18px; 
    }
</style>