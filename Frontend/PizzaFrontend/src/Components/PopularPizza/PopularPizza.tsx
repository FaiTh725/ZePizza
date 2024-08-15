
import styles from "./PopularPizza.module.css"

import pizza from "../../assets/Pizzas/11EF1EB095B2BBDE8E1230BD91995D9D.avif"
import FullScreenProduct from "../FullScreenProduct/FullScreenProduct";
import { useState } from "react";
import ProductSetting from "../ProductSetting/ProductSetting";

const PopularProduct = () => {
    const [isOpenFullScreen, setIsOpenFullScreen] = useState(false);

    return (
        <div onClick={() => setIsOpenFullScreen(!isOpenFullScreen)} className={styles.main}>
            <div className={styles.imgContainer}>
                <img src={pizza} alt="image product" />
            </div>
            <div className={styles.data}>
                <p className={styles.name}>Баварская</p>
                <p className={styles.price}>от 22,99 руб.</p>
            </div>
            <FullScreenProduct isClose={isOpenFullScreen} setIsClose={setIsOpenFullScreen}>
                <ProductSetting/>
            </FullScreenProduct>
        </div>
    )
}

export default PopularProduct;