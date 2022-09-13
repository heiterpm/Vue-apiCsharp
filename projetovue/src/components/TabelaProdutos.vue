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
                    <td><button id="nomeProd" @click="getProduto(produto.id);">{{ produto.name }}</button></td>
                    <td>{{ produto.preco }}</td>
                    <td>{{ produto.qtdEstoque }}</td>
                    <td id="botoestab"><button class="edit">Editar</button><button class="delete"
                            @click="deleteProduto(produto.id);">Excluir</button></td>
                </tr>
            </tbody>
        </table>
        <div id="addProd">
            <button>
                <router-link to="/CriarProduto">Adicionar Produto</router-link>
            </button>
        </div>

        <Modal v-show="isModalVisible" @close="closeModal" :produto="produto" />
    </div>
</template>

<script>
import Modal from '../components/Modal.vue';
import api from '@/services/api.js';
import Swal from 'sweetalert2';

export default {
    name: 'TabelaProdutos',
    components: {
        Modal
    },
    data() {
        return {
            produtos: [],
            produto: {
                Name: "",
                Descricao: "",
                Preco: "",
                qtdEstoque: "",
                Img: "",
                fileSrc: require("@/assets/noImage.jpg")
            },
            stringtest: "Olaola",
            isModalVisible: false
        }
    },
    methods: {
        limparTela() {
            this.produtos = [];
        },
        async getProdutos() {

            this.limparTela();

            api.get('Produtos/AllProdutos', this.getTokenConfig())
                .then(response => {
                    for (var i = 0; i < response.data.length; i++) {
                        this.produtos.push(response.data[i]);
                    }

                    this.produtos.sort((a, b) => {
                        return a.preco - b.preco;
                    })
                })
                .catch((error) => {
                    Swal.fire({
                        title: 'Erro',
                        text: 'Token nao autenticado',
                        background: '#222',
                        color: 'white',
                        confirmButtonColor: '#fcba03'
                    })
                        .then(() => {
                            this.$router.push({ name: "home" })
                        })
                })
        },

        async getProduto(id) {
            api.get('Produtos/GetProduto/' + id, this.getTokenConfig()).then(response => {
                this.produto = response.data;

                //Exibição de Imagens
                if (this.produto.imgByte != null && this.produto.imgByte.length > 0) {
                    this.produto.fileSrc = 'data:image/jpeg;base64,' + this.produto.imgByte;
                    this.produto.Img = 'data:image/jpeg;base64,' + this.produto.imgByte;
                    if (this.produto.fileSrc == "") {
                        this.produto.fileSrc = 'data:image/png;base64,' + this.produto.imgByte;
                        this.produto.Img = 'data:image/png;base64,' + this.produto.imgByte;
                    }
                }
                this.isModalVisible = true;
            })
        },
        async deleteProduto(id) {
            api.delete('Produtos/DeleteProduto/' + id, this.getTokenConfig()).then(response => {
                this.getProdutos();
            })
        },

        closeModal() {
            this.isModalVisible = false;
        },
        getTokenConfig() {
            var token = JSON.parse(localStorage.getItem('token'));
            const config = {
                headers: { Authorization: `Bearer ${token}` }
            };
            return config;
        }
    },
    mounted() {
        this.getProdutos();
    }
}
</script>

<style scoped>
#produtos {
    background: #222;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 70%;
    height: 70%;
    border-radius: 10px;
}

#produtos h1 {
    margin: 10px;
    text-align: center;
    color: white;
}

#tabelaProdutos {
    margin: auto;
    position: relative;
    width: 95%;
}

table {
    table-layout: fixed;
    border-collapse: collapse;
}

th,
td,
tr {
    border: 1px solid white;
    color: white;
    text-align: center;
    overflow: hidden;
    text-overflow: clip;
}

#botoestab {
    height: 30px;
    width: 200px;
}

#botoestab button {
    height: 100%;
    width: 50%;
    border: none;
}

#botoestab .edit {
    border: -1px;
    background-color: #fcba03;
    color: white;
    text-align: center;
    transition: .5s;
}

#botoestab .delete {
    background-color: red;
    color: white;
    text-align: center;
    transition: .5s;
}

#botoestab button:hover {
    font-size: 18px;
}

#nomeProd {
    color: white;
    transition: .5s;
    border: none;
    background: none;
    outline: none;
    font-size: 16px;
}

#nomeProd:hover {
    color: #fcba03;
    font-size: 18px;
}

#addProd {
    position: absolute;
    bottom: 20px;
    right: 20px;
}

#addProd button {
    width: 200px;
    height: 40px;
    border: none;
    border-radius: 10px;
    background: lightgreen;
    transition: .5s;
    font-weight: bolder;
}

#addProd button:hover {
    font-size: 18px;
}

#addProd a {
    text-decoration: none;
    color: black;
}
</style>