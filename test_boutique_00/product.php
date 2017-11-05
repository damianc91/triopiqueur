<?php include('header.php'); ?>

    <!-- Page Content -->
    <div class="container" height='200px'>

      <div id='pathzone'>
        chemin - du - produit
      </div>
      <div class="product-display">
        <div class="product-title">
          <h1>Titre du produit</h1>
        </div>
        <div class="product-img">
          <img src="images/app_photo.jpg" alt="photo_produit">
        </div>

        <div class='product-description'>
          <ul>
            <li>
              Grand capteur CMOS APS-C 18 millions de pixels pour un niveau de détail impressionnant
            </li>
            <li>
              Sélection automatique des meilleurs paramètres
            </li>
            <li>
              Prise de vue en continu jusqu'à 3 images par seconde
            </li>
            <li>
              Grand écran lumineux pour un affichage clair
            </li>
            <li>
              Créez des vidéos captivantes en toute simplicité
            </li>
            <li>
              Appliquez des effets créatifs à vos images
            </li>
            <li>
              Vidéos 1080p au rendu cinématographique
            </li>
            <li>
              Le flash n'est pas inclus
            </li>
          </ul>
        </div>


        <div class="product-zone-achat">
          <div class="prix">
            <p>450 €</p>
          </div>
          <div class="dispo">
            <p>Disponible</p>
          </div>
          <div class="btn-acheter">
            <button type="button">Acheter</button>
          </div>

        </div>

      </div>
    </div>


  <!-- Autres produits -->
<?php  include('other-product.php'); ?>


    <!-- Avis -->
    <div class="py-5 bg-color-avis">
      <div class="container">
        <div class="product-display">
          <h2 class="m-0 avis">Avis sur le produit</h2>


          <div class="row">

           <div class="container avis-comm">
             <p>M. Patate</p>
             <small class="text-muted text-right">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
             <p>Woooooooooow c'est super !</p>
           </div>

            <div class="container avis-comm">
              <p>M. Patate</p>
              <small class="text-muted text-right">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
              <p>Woooooooooow c'est super !</p>
            </div>

            <div class="container avis-comm">
              <p>M. Patate</p>
              <small class="text-muted text-right">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
              <p>Woooooooooow c'est super !</p>
            </div>

          </div>

          <!-- /.row -->

        </div>

      </div>
    </div> <!-- /.fin avis -->


    <!-- /.container -->


  <!-- Footer -->
<?php include('footer.php'); ?>