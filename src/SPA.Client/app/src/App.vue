<template>
  <section id="app" class="hero is-light is-bold is-fullheight">
    
    <Header></Header>

    <!-- Hero content: will be in the middle -->
    <div class="hero-body">
      <div class="container has-text-centered">
        <router-view />
      </div>
    </div>

    <Footer></Footer>
  </section>
</template>

<script>
import Header from '@/shared/Header.vue'
import Footer from '@/shared/Footer.vue'

export default {
  name: 'app',
  components: {
    Header,
    Footer
  }
}
</script>
