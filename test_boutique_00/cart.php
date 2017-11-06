<?php include('header.php'); ?>


<!-- Page Content -->
<div class="container container-cart" height='200px'>

    <div id='pathzone'>
        chemin - du - panier
    </div>
    <div class="product-display">
        <div class="product-title">
            <h1>Votre panier</h1>
        </div>
        <div class="card-list">


            <div class="col-lg-8 col-md-6 mb-4 product-card">
                <div class="card h-100 ">
                    <div class="img-product-card">
                        <a href="#"><img class="card-img-top" src="images/app_photo.jpg" alt=""></a>
                    </div>

                    <div class="card-body">
                        <h4 class="card-title">
                            <a href="#">Nom du produit</a>
                        </h4>
                        <h5>450€</h5>
                        <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>
                        <a href="">Supprimer du panier</a>
                    </div>

                </div>
            </div>


            <div class="col-lg-8 col-md-6 mb-4 product-card">
                <div class="card h-100 ">
                    <div class="img-product-card">
                        <a href="#"><img class="card-img-top" src="images/app_photo.jpg" alt=""></a>
                    </div>

                    <div class="card-body">
                        <h4 class="card-title">
                            <a href="#">Nom du produit</a>
                        </h4>
                        <h5>450€</h5>
                        <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>
                        <a href="">Supprimer du panier</a>
                    </div>

                </div>
            </div>
        </div> <!-- fin liste panier -->

        <div class="total-panier">
            <h3>Frais de livraison : </h3>
            <p>OFFERT</p>
            <h3>Total </h3>
            <p>900€</p>
            <div class="btn-acheter">
                <a href="delivery_form.php"><button type="button">Commander</button></a>
            </div>

        </div>


    </div>
</div>

    <!-- Autres produits -->
<?php  include('other-product.php'); ?>





<!-- /.container -->


    <!-- Footer -->
<?php include('footer.php'); ?>
