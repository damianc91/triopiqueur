<link rel="stylesheet" href="./css/recap.css">
<?php include('header.php'); ?>
<script type="text/javascript">
var $_POST = <?php echo json_encode($_POST); ?>;
</script>
<div class="container">
  <div class="recap">
    <h4>Vos informations de commande</h4>
    <div class="infos">
        <div class="labels">
          <p class="label">Prenom: </p>
          <p class="label"> Nom: </p>
          <p class="label">Adresse mail: </p>
          <p class="label">Adresse: </p>
          <p class="label">Ville: </p>
          <p class="label">Code postal: </p>
        </div>
        <div class="datas">
          <p class="val">Pierre</p>
          <p class="val">Dupond</p>
          <p  class="val"> pierre.d@gmail.com</p>
          <p class="val">5 rue du Général de Gaulle</p>
          <p class="val">Bagnolet</p>
          <p class="val"> 93170</p>
        </div>
      </div>
    </div >
      <div class="infos">
        <h4>Article commandé</h4>
        <div class="imgbox">
      <div class="col-lg-3 col-md-6 mb-4 imgbox">
      <div class="card h-100">
        <a href="product.php"><img class="card-img-top" src="images/app_photo.jpg" alt=""></a>
        <div class="card-body">
          <h4 class="card-title">
            <a href="product.php">Item One</a>
          </h4>
          <h5>$24.99</h5>
          <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>
        </div>
        <div class="card-footer">
          <small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
        </div>
      </div>
    </div>
    </div>
    </div>
  </div>
</div>
<?php include('footer.php'); ?>
