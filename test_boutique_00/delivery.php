<?php include('header.php'); ?>

    <!-- Page Content -->
    <div class="container container-cart" height='200px'>

        <div id='pathzone'>
            chemin - du - panier
        </div>
        <div class="product-display">
            <div class="product-title">
                <h1>Mode de livraison</h1>
            </div>
            <div class="card-list">


                <div class="col-lg-8 col-md-6 mb-4 product-card">
                    <div class="card h-100 form-delivery">
                        <form action="paiement_securise.php">
                            <fieldset>


                                <label for="text">Nom</label>
                                <input type="text" name="Nom" id="text">

                                <label for="text">Prenom</label>
                                <input type="text" name="Prenom" id="text">

                                <label for="text">Adresse</label>
                                <input type="text" name="Adresse" id="text">

                                <label for="text">Ville</label>
                                <input type="text" name="Adresse" id="text">


                                <label for="numeric">Code postal</label>
                                <input type="number" name="numeric" id="numeric" >


                                <label for="email">Email</label>
                                <input type="email" id="email" name="email">

                                <div class="btn-acheter">
                                    <button>
                                        Poursuivre la commande
                                    </button>

                                </div>

                            </fieldset>
                        </form>

                    </div>
                </div>



            </div> <!-- fin liste panier -->

            <div class="total-panier">
                <h3>Frais de livraison : </h3>
                <p>OFFERT</p>
                <h3>Total </h3>
                <p>900&euro;</p>


            </div>


        </div>
    </div>


<?php include('footer.php'); ?>