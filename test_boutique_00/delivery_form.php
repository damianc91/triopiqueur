



<?php include('header.php'); ?>
<link href="./delivery_form/delivery_form.css" rel="stylesheet">
<div class="container">
    <form class="form" action="./recap.php" method="post"  id="delivery_form">
  <!-- Text input-->
    <fieldset class="info-clt">
      <legend>Informations personnelles</legend>
      <div class="form-group">
        <label class="col-md-3 control-label">Prénom</label>
        <div class="col-md-3 inputGroupContainer">
        <div class="input-group">
        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
        <input  name="first_name" placeholder="First Name" class="form-control"  type="text">
          </div>
        </div>
      </div>




      <!-- Text input-->

      <div class="form-group">
        <label class="col-md-3 control-label" >Nom</label>
          <div class="col-md-3 inputGroupContainer">
          <div class="input-group">
        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
        <input name="last_name" placeholder="Last Name" class="form-control"  type="text">
          </div>
        </div>
      </div>

      <!-- Text input-->
             <div class="form-group">
        <label class="col-md-3 control-label">E-Mail</label>
          <div class="col-md-3 inputGroupContainer">
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
        <input name="email" placeholder="Adresse E-Mail" class="form-control"  type="text">
          </div>
        </div>
      </div>


      <!-- Text input-->

      <div class="form-group">
        <label class="col-md-3 control-label">N° de téléphone</label>
          <div class="col-md-3 inputGroupContainer">
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>
        <input name="phone" placeholder="+336 12 34 56 78" class="form-control" type="text">
          </div>
        </div>
      </div>
    </fieldset>

    <div class="total-panier">
        <h3>Frais de livraison : </h3>
        <p>OFFERT</p>
        <h3>Total </h3>
        <p>900&euro;</p>
      </div><!---->

      <div class="adds">


    <fieldset id="add_factu" class="adresse">
      <legend>Adresse de Facturation</legend>
      <div class="form-group">
        <label class="col-md-3 control-label">Adresse</label>
          <div class="col-md-3 inputGroupContainer">
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
              <input name="Adresse" placeholder="Adresse" class="form-control" type="text">
          </div>
        </div>
      </div>
      <div class="form-group">
        <label class="col-md-3 control-label">Ville</label>
          <div class="col-md-3 inputGroupContainer">
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
              <input name="Ville" placeholder="Ville" class="form-control"  type="text">
          </div>
        </div>
      </div>
      <div class="form-group">
        <label class="col-md-3 control-label">Code Postal</label>
          <div class="col-md-3 inputGroupContainer">
            <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
              <input name="zip" placeholder="Code Postal" class="form-control"  type="text">
          </div>
        </div>
      </div>
    </fieldset>

    <fieldset id="add_livr" class="adresse">
      <legend>Adresse de Livraison</legend>
      <div class="form-group">
        <label class="col-md-3 control-label">Adresse</label>
          <div class="col-md-3 inputGroupContainer">
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
              <input name="Adresse" placeholder="Adresse" class="form-control" type="text">
          </div>
        </div>
      </div>
      <div class="form-group">
        <label class="col-md-3 control-label">Ville</label>
          <div class="col-md-3 inputGroupContainer">
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
              <input name="Ville" placeholder="Ville" class="form-control"  type="text">
          </div>
        </div>
      </div>
      <div class="form-group">
        <label class="col-md-3 control-label">Code Postal</label>
          <div class="col-md-3 inputGroupContainer">
            <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
              <input name="zip" placeholder="Code Postal" class="form-control"  type="text">
          </div>
        </div>
      </div>
    </fieldset>
    </div>
    <!-- Button -->
    <div class="form-group">
      <label class="col-md-3 control-label"></label>
      <div class="col-md-3">
        <button type="submit" class="btn btn-acheter" > Envoyer <span class="glyphicon glyphicon-send"></span></button>
      </div>
    </div>
    </form>
  </div>
    <?php include('footer.php'); ?>

    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="./delivery_form/js/form-validator/jquery.form-validator.js"></script>
