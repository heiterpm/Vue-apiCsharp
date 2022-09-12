<template>
  <transition name="modal-fade">
    <div class="modal-backdrop">
      <div class="modal" role="dialog" aria-labelledby="modalTitle" aria-describedby="modalDescription">
        <header class="modal-header" id="modalTitle">
          <slot name="header">
            {{produto.name}}
          </slot>
          <button type="button" class="btn-close" @click="close" aria-label="Close modal">
            X
          </button>
        </header>

        <section class="modal-body" id="modalDescription">
          <slot name="body">
            <img id="imagem" :src="produto.fileSrc" />
            <ul>
              <li>Preco: {{ produto.preco}}</li>
              <li>Estoque: {{ produto.qtdEstoque}}</li>
            </ul>
            <br>
            Descrição:
            <div id="descricaoModal">{{produto.descricao}}</div>
          </slot>
        </section>

        <footer class="modal-footer">
          <slot name="footer">
          </slot>
          <button type="button" class="btn-green" @click="close" aria-label="Close modal">
            Close me!
          </button>
        </footer>
      </div>
    </div>
  </transition>
</template>

<script>
export default {
  name: 'Modal',
  methods: {
    close() {
      this.$emit('close');
    },
  },
  props: ['produto']
};
</script>
  
<style>
.modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.3);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  background: #222;
  box-shadow: 2px 2px 20px 1px;
  overflow-x: auto;
  display: flex;
  flex-direction: column;
}

.modal-header,
.modal-footer {
  padding: 15px;
  display: flex;
}

.modal-header {
  position: relative;
  border-bottom: 1px solid #eeeeee;
  color: #fcba03;
  justify-content: space-between;
}

.modal-footer {
  border-top: 1px solid #eeeeee;
  flex-direction: column;
}

.modal-body {
  position: relative;
  padding: 20px 10px;
  color: white;
}

.btn-close {
  position: absolute;
  top: 0;
  right: 0;
  border: none;
  font-size: 20px;
  padding: 10px;
  cursor: pointer;
  font-weight: bold;
  color: #fcba03;
  background: transparent;
}

.btn-green {
  color: white;
  background: #fcba03;
  border: 1px solid #fcba03;
  border-radius: 2px;
}

.modal-fade-enter,
.modal-fade-leave-to {
  opacity: 0;
}

.modal-fade-enter-active,
.modal-fade-leave-active {
  transition: opacity .5s ease;
}

#descricaoModal {
  display: block;
  border: 2px solid black;
  width: 300px;
  height: 100%;
  min-height: 100px;
  max-height: 500px;
  justify-content: start;
  align-items: flex-start;
  overflow-y: scroll;
  overflow-y: hidden;
}

#imagem {
  width: 400px;
}
</style>