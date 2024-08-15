
import styles from "./SettingButton.module.css"

interface SettingButtonProps {
    text: string
}

const SettingButton = ({text}: SettingButtonProps) => {
    return (
        <button className={styles.container}>
            <p className={styles.content}>{text}</p>
        </button>
    )
}

export default SettingButton;