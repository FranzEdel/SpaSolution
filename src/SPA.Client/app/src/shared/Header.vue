<template>
    <!-- Hero head: will stick at the top -->
    <div class="hero-head">
      <header class="navbar">
        <div class="container">
          <div class="navbar-brand">
            <a class="navbar-item">
              <img src="https://bulma.io/images/bulma-type-white.png" alt="Logo">
            </a>
            <span class="navbar-burger" data-target="navbarMenuHeroC">
              <span></span>
              <span></span>
              <span></span>
            </span>
          </div>
          <div id="navbarMenuHeroC" class="navbar-menu">
            <div class="navbar-end">
              <a class="navbar-item is-active">
                Inicio
              </a>
              <a class="navbar-item">
                Clientes
              </a>
              <a class="navbar-item">
                Productos
              </a>
              <a class="navbar-item">
                Ordenes
              </a>
            </div>
          </div>
        </div>
      </header>
    </div>
</template>

<script>
export default {
    name: 'Header'
}
</script>
