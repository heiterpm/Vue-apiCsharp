<template>
    <div id="formProduto">
        <h1>Produtos</h1>
        <form method="post" id="formlogin">
            <div class="campoInput">
                <img :src="produto.fileSrc" />
                <input type="file" accept="image/*" @change="uploadImage($event)">
            </div>
            <div class="campoInput">
                <label for="text">Nome do produto</label><input v-model="produto.Name" type="text">
            </div>
            <div class="campoInput">
                <label for="text">Descricão</label><textarea v-model="produto.Descricao"></textarea>
            </div>
            <div class="campoInput">
                <label for="text">Preço do produto</label><input type="text" v-model="produto.Preco">
            </div>
            <div class="campoInput">
                <label for="text">Quantidade Estoque</label><input type="text" v-model="produto.qtdEstoque">
            </div>
            <button v-on:click="save">Cadastrar</button>
        </form>
    </div>
</template>

<script>
import api from '@/services/api'
import Swal from 'sweetalert2';

export default {
    name: 'ProdutoForm',
    data() {
        return {
            produto: {
                Name: "",
                Descricao: "",
                Preco: "",
                qtdEstoque: "",
                Img: "",
                fileSrc: require("@/assets/noImage.jpg")
            }
        }
    },
    methods: {
        save(e) {
            e.preventDefault(e)
            if (this.validaForm()) {
                var formData = new FormData();
                for (var key in this.produto) {
                    formData.append(key, this.produto[key])
                }

                formData.append("Img", this.Img);

                api.post('Produtos/AddProduto', formData, this.getTokenConfig())
                    .then(function (response) {
                    })
                this.$router.push({ name: "Produtos" });
            }
        },

        uploadImage(e) {
            this.produto.Img = e.target.files[0];
            this.produto.fileSrc = window.URL.createObjectURL(this.produto.Img);
        },

        getTokenConfig() {
            var token = JSON.parse(localStorage.getItem('token'));
            const config = {
                headers: { Authorization: `Bearer ${token}` }
            };
            return config;
        },

        validaForm() {
            if (!this.produto.Name) {
                Swal.fire({
                    title: 'Erro',
                    text: 'Nome do Produto Vazio',
                    background: '#222',
                    color: 'white',
                    confirmButtonColor: '#fcba03'
                })
                return;
            }
            if (!this.produto.Preco) {
                Swal.fire({
                    title: 'Erro',
                    text: 'Campo Preco Vazio',
                    background: '#222',
                    color: 'white',
                    confirmButtonColor: '#fcba03'
                })
                return;
            }
            if (!this.produto.qtdEstoque) {
                Swal.fire({
                    title: 'Erro',
                    text: 'Campo Estoque Vazio',
                    background: '#222',
                    color: 'white',
                    confirmButtonColor: '#fcba03'
                })
                return;
            }
            return true;
        },
    }
}
</script>

<style>
#formProduto {
    background: #222;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 30%;
    height: 70%;
    border-radius: 10px;
    text-align: center;
    color: white;
}

#formProduto h1 {
    margin: 10px;
    color: white;
}

#formProduto .campoInput {
    margin-top: 20px;
}

#formProduto .campoInput input {
    display: block;
    margin-left: auto;
    margin-right: auto;
}

#formProduto textarea {
    display: block;
    width: 300px;
    height: 100%;
    min-height: 100px;
    max-height: 500px;
    overflow-y: scroll;
    overflow-y: hidden;
    resize: none;
    margin-left: auto;
    margin-right: auto;
}

.campoInput Img {
    width: 200px;
}
</style>