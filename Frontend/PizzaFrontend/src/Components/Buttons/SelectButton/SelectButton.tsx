
import { ReactNode } from "react";
import styles from "./SelectButton.module.css"

interface SelectButtonProps {
    children: ReactNode;
    action: () => void
}

const SelectButton = ({children, action}:SelectButtonProps) => {
    return (
        <button className={styles.btn}>
            {
                children
            }
        </button>
    )
}

export default SelectButton;
