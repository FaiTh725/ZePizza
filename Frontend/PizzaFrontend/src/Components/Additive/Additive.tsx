import styles from "./Additive.module.css"

import img from "../../assets/Pizzas/additievs.png"

const Additive = () => {
    return (
        <div className={styles.container}>
            <div className={styles.imgContainer}>
                <img src={img} alt="additievs" />
            </div>
            <p className={styles.name}>Моцарелла</p>
            <p className={styles.price}>4,49 руб.</p>
        </div>
    )
}

export default Additive;