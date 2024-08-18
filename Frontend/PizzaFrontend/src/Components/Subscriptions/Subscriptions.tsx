
import SubscptionCheckBox from "../CheckBoxes/SubscriptionCheckbox/SubscriptionCheckBox";
import styles from "./Subscription.module.css"

const Subscptions = () => {
    return (
        <div className={styles.container}>
            <h2 className={styles.sectionName}>Подпиcки</h2>
            <div className={styles.subscptions}>
                <SubscptionCheckBox/>
            </div>
        </div>
    )
}

export default Subscptions;